interface JQueryStatic {
    connection: SignalRTaskManager.Components.Hubs.IHubs;
    notify(p: { delay: number;message: string });
}