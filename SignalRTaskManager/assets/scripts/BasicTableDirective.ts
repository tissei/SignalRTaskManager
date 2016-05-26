module SignalRTaskManager.Components.Tables {
    "use strict";

    import NotificationHubService = Components.Hubs.NotificationHubService;

    class BasicTableDirective implements ng.IDirective {
        static instance = () => { return new BasicTableDirective(); }

        restrict = "E";
        scope = true;
        bindToController = {
            apiRoute: "@",
            apiController: "@"
        };
        controller = BasicTableController;
        controllerAs = "tableCtrl";
    }

    class BasicTableController {
        static $inject = ["$http", "notificationHub"];

        apiController: string;
        itens;

        constructor(private $http: ng.IHttpService, private notificationHub: NotificationHubService) {
            this.loadData();

            notificationHub.setRefresh(this.loadData);
        }

        loadData = () => {
            this.$http.get(this.apiController).success((response) => {
                this.itens = response;
            });
        }
    }

    angularTaskManager.directive("basicTable", BasicTableDirective.instance);
}