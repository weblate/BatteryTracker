﻿using System.Linq;
using BatteryTracker.Contracts.Services;
using BatteryTracker.Helpers;
using BatteryTracker.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Windows.AppLifecycle;
using Windows.ApplicationModel.Activation;
using WinUIEx;

namespace BatteryTracker.Activation;

public sealed class LaunchActivationHandler : ActivationHandler<AppActivationArguments>
{
    public const string OpenSettingsCommandArg = "--open-settings";

    private readonly ILogger<LaunchActivationHandler> _logger;
    private readonly IAppNotificationService _notificationService;

    public LaunchActivationHandler(ILogger<LaunchActivationHandler> logger, IAppNotificationService notificationService)
    {
        _logger = logger;
        _notificationService = notificationService;
    }

    protected override bool CanHandleInternal(AppActivationArguments args)
    {
        return args.Kind == ExtendedActivationKind.Launch;
    }

    protected override async Task HandleInternalAsync(AppActivationArguments args)
    {
        // Handle single instance notification logic
        var app = (App)Application.Current;
        if (!app.HasLaunched)
        {
            app.HasLaunched = true;
        }
        else
        {
            _notificationService.Show("InstanceRunningMessage".Localized());
            return;
        }

        // Handle command line args
        if (args.Data is ILaunchActivatedEventArgs launchArgs)
        {
            string[] argStrings = launchArgs.Arguments.Split(' ');
            _logger.LogInformation($"App launched with command line args: [{string.Join(", ", argStrings)}]");

            if (argStrings.Contains(OpenSettingsCommandArg))
            {
                App.GetService<INavigationService>().NavigateTo(typeof(SettingsViewModel).FullName!);
                App.MainWindow.Show();
            }
        }

        await Task.CompletedTask;
    }
}
