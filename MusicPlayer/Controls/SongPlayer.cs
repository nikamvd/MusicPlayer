using System;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;

namespace MusicPlayer.Controls
{
    public class SongPlayer : MediaElement
    {
        public SongPlayer()
        {
            PlayOrPauseCommand = new Command(ExecutePlayOrPauseCommand);
            DragStartedCommand = new Command(ExecuteDragStartedCommand);
            DragCompletedCommand = new Command(ExecuteDragCompletedCommand);
        }

        private void ExecuteDragCompletedCommand(object obj)
        {
            SeekTo(TimeSpan.FromSeconds(SliderPosition));
            Play();
        }

        private void ExecuteDragStartedCommand(object obj)
        {
            Pause();
        }

        private void ExecutePlayOrPauseCommand(object obj)
        {
            if (CurrentState == MediaElementState.Stopped ||
                CurrentState == MediaElementState.Paused)
            {
                // to reset the position
                if(CurrentState == MediaElementState.Stopped)
                {
                    Stop();
                }
                Play();
            }
            else if (CurrentState == MediaElementState.Playing)
            {
                Pause();
            }
        }

        /// <summary>
        /// Bindable Command to handle MediaElement Play and Pause functionalities
        /// </summary>
        public static BindableProperty PlayOrPauseCommandProperty =
                BindableProperty.Create(nameof(PlayOrPauseCommand), typeof(ICommand), typeof(SongPlayer), null, BindingMode.OneWayToSource);

        /// <summary>
        /// SelectedDateChangedCommand - Backed by Bindable Command SelectedDateChangedCommandProperty
        /// </summary>
        public ICommand PlayOrPauseCommand
        {
            get { return (ICommand)GetValue(PlayOrPauseCommandProperty); }
            set { SetValue(PlayOrPauseCommandProperty, value); }
        }

        /// <summary>
        /// Bindable Command to handle Drag Started on slider
        /// </summary>
        public static BindableProperty DragStartedCommandProperty =
                BindableProperty.Create(nameof(DragStartedCommand), typeof(ICommand), typeof(SongPlayer), null, BindingMode.OneWayToSource);

        /// <summary>
        /// DragStartedCommand - Backed by Bindable Command DragStartedCommandProperty
        /// </summary>
        public ICommand DragStartedCommand
        {
            get { return (ICommand)GetValue(DragStartedCommandProperty); }
            set { SetValue(DragStartedCommandProperty, value); }
        }

        /// <summary>
        /// Bindable Command to handle DragCompletedCommand on slider
        /// </summary>
        public static BindableProperty DragCompletedCommandProperty =
                BindableProperty.Create(nameof(DragCompletedCommand), typeof(ICommand), typeof(SongPlayer), null, BindingMode.OneWayToSource);

        /// <summary>
        /// DragCompletedCommand - Backed by Bindable Command DragCompletedCommandProperty
        /// </summary>
        public ICommand DragCompletedCommand
        {
            get { return (ICommand)GetValue(DragCompletedCommandProperty); }
            set { SetValue(DragCompletedCommandProperty, value); }
        }

        /// <summary>
        /// Bindable property for slider current position
        /// </summary>
        public static BindableProperty SliderPositionProperty =
                BindableProperty.Create(nameof(SliderPosition), typeof(double), typeof(SongPlayer), null, BindingMode.OneWay);

        /// <summary>
        /// SliderPosition - Backed by Bindable property SliderPositionProperty
        /// </summary>
        public double SliderPosition
        {
            get { return (double)GetValue(SliderPositionProperty); }
            set { SetValue(SliderPositionProperty, value); }
        }
    }
}

