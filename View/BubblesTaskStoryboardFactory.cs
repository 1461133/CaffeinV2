using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using ViewModel;
using Thriple.Easing;
using View;

namespace BubbleBurst.View
{
    /// <summary>
    /// Creates Storyboards used to provide animated 
    /// transitions when a bubble group bursts or un-bursts.
    /// </summary>
    internal class BubblesTaskStoryboardFactory
    {
        #region Constructor

        internal BubblesTaskStoryboardFactory(BubbleCanvas bubbleCanvas)
        {
            if (bubbleCanvas == null)
                throw new ArgumentNullException("bubbleCanvas");

            _bubbleCanvas = bubbleCanvas;
        }

        #endregion // Constructor

        #region Methods

        #region Internal

        internal Storyboard CreateStoryboard(_GAME_3BTask task)
        {
            int millisecondsPerUnit;
            Func<ContentPresenter, double> getTo;
            DependencyProperty animatedProperty;
            IEnumerable<_GAME_3BViewModel> bubbles;

            this.GetStoryboardCreationData(task,
                out millisecondsPerUnit,
                out getTo,
                out animatedProperty,
                out bubbles);

            return this.CreateStoryboard(
                task,
                millisecondsPerUnit,
                getTo,
                animatedProperty,
                bubbles.ToArray());
        }

        #endregion // Internal

        #region Private

        void GetStoryboardCreationData(_GAME_3BTask task,
          out int millisecondsPerUnit,
          out Func<ContentPresenter, double> getTo,
          out DependencyProperty animatedProperty,
          out IEnumerable<_GAME_3BViewModel> bubbles)
        {
            switch (task.TaskType)
            {
                case _GAME_3BTaskType.Burst:
                    millisecondsPerUnit = 250;
                    getTo = cp => (task.IsUndo ? 1.0 : 0.0);
                    animatedProperty = UIElement.OpacityProperty;
                    bubbles = task.Bubbles;
                    break;

                case _GAME_3BTaskType.MoveDown:
                    millisecondsPerUnit = 115;
                    getTo = _bubbleCanvas.CalculateTop;
                    animatedProperty = Canvas.TopProperty;

                    // Sort the bubbles to ensure that the columns move 
                    // in sync with each other in an appealing way.
                    bubbles =
                        from bubble in task.Bubbles
                        orderby bubble.PreviousColumn
                        orderby bubble.PreviousRow descending
                        select bubble;
                    break;

                case _GAME_3BTaskType.MoveRight:
                    millisecondsPerUnit = 115;
                    getTo = _bubbleCanvas.CalculateLeft;
                    animatedProperty = Canvas.LeftProperty;

                    // Sort the bubbles to ensure that the rows move 
                    // in sync with each other in an appealing way.
                    bubbles =
                        from bubble in task.Bubbles
                        orderby bubble.PreviousRow descending
                        orderby bubble.PreviousColumn descending
                        select bubble;
                    break;

                default:
                    throw new ArgumentException("Unrecognized BubblesTaskType: " + task.TaskType);
            }

            if (task.IsUndo)
            {
                bubbles = bubbles.Reverse();
            }
        }

        Storyboard CreateStoryboard(
            _GAME_3BTask task,
            int millisecondsPerUnit,
            Func<ContentPresenter, double> getTo,
            DependencyProperty animatedProperty,
            _GAME_3BViewModel[] bubbles)
        {
            if (!bubbles.Any())
                return null;

            var storyboard = new Storyboard();
            var targetProperty = new PropertyPath(animatedProperty);
            var beginTime = TimeSpan.FromMilliseconds(0);
            var beginTimeIncrement = TimeSpan.FromMilliseconds(millisecondsPerUnit / bubbles.Count());

            foreach (ContentPresenter presenter in this.GetBubblePresenters(bubbles))
            {
                var bubble = presenter.DataContext as _GAME_3BViewModel;
                var duration = CalculateDuration(task.TaskType, bubble, millisecondsPerUnit);
                var to = getTo(presenter);
                var anim = new EasingDoubleAnimation
                {
                    BeginTime = beginTime,
                    Duration = duration,
                    Equation = EasingEquation.CubicEaseIn,
                    To = to,
                };

                Storyboard.SetTarget(anim, presenter);
                Storyboard.SetTargetProperty(anim, targetProperty);

                if (IsTaskStaggered(task.TaskType))
                {
                    beginTime = beginTime.Add(beginTimeIncrement);
                }

                storyboard.Children.Add(anim);
            }

            return storyboard;
        }

        IEnumerable<ContentPresenter> GetBubblePresenters(IEnumerable<_GAME_3BViewModel> bubbles)
        {
            var bubblePresenters = new List<ContentPresenter>();
            var contentPresenters = _bubbleCanvas.Children.Cast<ContentPresenter>().ToArray();
            foreach (_GAME_3BViewModel bubble in bubbles)
            {
                var bubblePresenter = contentPresenters.FirstOrDefault(cp => cp.DataContext == bubble);
                if (bubblePresenter != null)
                {
                    bubblePresenters.Add(bubblePresenter);
                }
            }
            return bubblePresenters;
        }

        static Duration CalculateDuration(
            _GAME_3BTaskType taskType,
            _GAME_3BViewModel bubble,
            int millisecondsPerUnit)
        {
            int totalMilliseconds;
            switch (taskType)
            {
                case _GAME_3BTaskType.Burst:
                    totalMilliseconds = millisecondsPerUnit;
                    break;

                case _GAME_3BTaskType.MoveDown:
                    totalMilliseconds = millisecondsPerUnit * Math.Abs(bubble.Row - bubble.PreviousRow);
                    break;

                case _GAME_3BTaskType.MoveRight:
                    totalMilliseconds = millisecondsPerUnit * Math.Abs(bubble.Column - bubble.PreviousColumn);
                    break;

                default:
                    throw new ArgumentException("Unrecognized BubblesTaskType value: " + taskType, "taskType");
            }
            return new Duration(TimeSpan.FromMilliseconds(totalMilliseconds));
        }

        static bool IsTaskStaggered(_GAME_3BTaskType taskType)
        {
            return taskType != _GAME_3BTaskType.Burst;
        }

        #endregion // Private

        #endregion // Methods

        #region Fields

        readonly BubbleCanvas _bubbleCanvas;

        #endregion // Fields
    }
}