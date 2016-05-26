module SignalRTaskManager.Components.Hubs {
    export interface INotificationHubConnection {
        client;
    }

    export class NotificationHubService {
        static $inject = ["hubConnection", "notificationHubConnection"];

        refresh: Function;

        constructor(private hubConnection: IHub, private notificationHubConnection: INotificationHubConnection) {
            hubConnection.start();

            notificationHubConnection.client.notify = this.notify;
        }

        setRefresh = (callBack: Function): void => {
            this.refresh = callBack;
        }

        notify = (message: string): void => {
            var self = this;
            $.notify({ delay: 5000, message: message });
            self.refresh();
        }
    }

    angularTaskManager.service("notificationHubConnection", () => { return $.connection.notificationHub; });
    angularTaskManager.service("hubConnection", () => { return $.connection.hub; });
    angularTaskManager.service("notificationHub", NotificationHubService);
}