var SignalRTaskManager;
(function (SignalRTaskManager) {
    var Components;
    (function (Components) {
        var Hubs;
        (function (Hubs) {
            var NotificationHubService = (function () {
                function NotificationHubService(hubConnection, notificationHubConnection) {
                    var _this = this;
                    this.hubConnection = hubConnection;
                    this.notificationHubConnection = notificationHubConnection;
                    this.setRefresh = function (callBack) {
                        _this.refresh = callBack;
                    };
                    this.notify = function (message) {
                        var self = _this;
                        $.notify({ delay: 5000, message: message });
                        self.refresh();
                    };
                    hubConnection.start();
                    notificationHubConnection.client.notify = this.notify;
                }
                NotificationHubService.$inject = ["hubConnection", "notificationHubConnection"];
                return NotificationHubService;
            })();
            Hubs.NotificationHubService = NotificationHubService;
            angularTaskManager.service("notificationHubConnection", function () { return $.connection.notificationHub; });
            angularTaskManager.service("hubConnection", function () { return $.connection.hub; });
            angularTaskManager.service("notificationHub", NotificationHubService);
        })(Hubs = Components.Hubs || (Components.Hubs = {}));
    })(Components = SignalRTaskManager.Components || (SignalRTaskManager.Components = {}));
})(SignalRTaskManager || (SignalRTaskManager = {}));
//# sourceMappingURL=NotificationHub.js.map