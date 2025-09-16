using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Plugin.Maui.Calendar.Controls;
using Plugin.Maui.Calendar.Models;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace EkandidatoApp;

public partial class ElectionCalendar : ContentPage
{
    private Calendar _calendar;
    private EventCollection allEvents = new EventCollection();

    public class Event
    {
        public required string Name { get; set; }
        public required string Time { get; set; }
        public required Color DotColor { get; set; }
        public required DateTime Date { get; set; }
    }

    public ElectionCalendar()
    {
        InitializeComponent();

        allEvents = new EventCollection
        {
            [new DateTime(2025, 10, 15)] = new List<Event>
            {
                new Event { Name = "Campaign Launch", Time = "1:30 PM", DotColor = Color.FromArgb("#2E6A3E"), Date = new DateTime(2025, 11, 3) }
            },
            [new DateTime(2025, 11, 1)] = new List<Event>
            {
                new Event { Name = "Voter Registration", Time = "9:00 AM", DotColor = Color.FromArgb("#2E6A3E"), Date = new DateTime(2025, 11, 5) }
            },
            [new DateTime(2025, 11, 3)] = new List<Event>
            {
                new Event { Name = "Election Day", Time = "8:00 PM", DotColor = Color.FromArgb("#2E6A3E"), Date = new DateTime(2025, 11, 15) },
                new Event { Name = "Vote Counting and Certification", Time = "7:00 PM", DotColor = Color.FromArgb("#2E6A3E"), Date = new DateTime(2025, 11, 15) }
            },
            [new DateTime(2025, 11, 4)] = new List<Event>
            {
                new Event { Name = " Results Announcement", Time = "8:00 PM", DotColor = Color.FromArgb("#2E6A3E"), Date = new DateTime(2025, 11, 15) }            }
        };

        _calendar = new Calendar
        {
            ShownDate = DateTime.Today,
            SelectedDate = DateTime.Today,
            VerticalOptions = LayoutOptions.Fill,
            HorizontalOptions = LayoutOptions.Fill,
            BackgroundColor = Colors.Transparent,
            Events = allEvents,
            SwipeToChangeMonthEnabled = false
        };

        _calendar.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == nameof(Calendar.SelectedDate) || e.PropertyName == nameof(Calendar.Events))
            {
                if (_calendar.SelectedDate.HasValue)
                {
                    if (allEvents.ContainsKey(_calendar.SelectedDate.Value.Date))
                    {
                        EventsList.ItemsSource = allEvents[_calendar.SelectedDate.Value.Date];
                    }
                    else
                    {
                        EventsList.ItemsSource = null;
                    }
                }
            }
            if (e.PropertyName == nameof(Calendar.ShownDate))
            {
                MonthLabel.Text = _calendar.ShownDate.ToString("MMMM yyyy");
            }
        };

        CalendarContentPresenter.Content = _calendar;
        MonthLabel.Text = _calendar.ShownDate.ToString("MMMM yyyy");

        if (allEvents.ContainsKey(DateTime.Today.Date))
        {
            EventsList.ItemsSource = allEvents[DateTime.Today.Date];
        }
    }
}