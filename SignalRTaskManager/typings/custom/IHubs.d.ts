declare module SignalRTaskManager.Components.Hubs {
    interface IHubs {
        hub: IHub;
        notificationHub: INotificationHubConnection;
    }

    interface IHub {
        start: Function;
    }
}