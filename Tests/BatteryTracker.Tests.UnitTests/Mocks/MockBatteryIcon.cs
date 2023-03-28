﻿using BatteryTracker.Contracts.Services;
using BatteryTracker.Views;
using H.NotifyIcon;
using Microsoft.Extensions.Logging;

namespace BatteryTracker.Tests.UnitTests.Mocks
{
    internal class MockBatteryIcon : BatteryIcon
    {
        public MockBatteryIcon(IAppNotificationService notificationService, ILogger<MockBatteryIcon> logger)
            : base(notificationService, logger)
        {
        }

        public new bool EnableLowPowerNotification;

        public new int LowPowerNotificationThreshold { get; set; }

        public new bool EnableHighPowerNotification;

        public new int HighPowerNotificationThreshold { get; set; }

        public new bool EnableFullyChargedNotification;

        public new async Task InitAsync(TaskbarIcon icon)
        {
            await Task.CompletedTask;
        }

        public new void Dispose()
        {
        }

        public new async Task AdaptToDpiChange(double rastScale)
        {
            await Task.CompletedTask;
        }
    }
}
