﻿using BatteryTracker.Contracts.Services;
using BatteryTracker.Models;
using Microsoft.UI.Xaml;

namespace BatteryTracker.Tests.UnitTests.Mocks;

public class MockSettingsService : ISettingsService
{
    public IList<AppLanguageItem> Languages { get; }

    public bool EnableFullyChargedNotification { get; set; }

    public bool EnableLowPowerNotification { get; set; }

    public int LowPowerNotificationThreshold { get; set; }

    public bool EnableHighPowerNotification { get; set; }

    public int HighPowerNotificationThreshold { get; set; }

    public ElementTheme Theme { get; set; }

    public AppLanguageItem Language { get; set; }

    public bool RunAtStartup { get; set; }

    public MockSettingsService()
    {
        Languages = new List<AppLanguageItem>
        {
            new("en-US"),
            new("zh-Hans"),
        };
        Language = Languages[0];
    }
}
