define([], () => {
    let subscribers = [];
    let lastEvent = undefined;

    let subscribe = (event, callback, target) => {
        let subscriber = { event, callback, target };

        if (!subscribers.find(x => x.target === target && x.event === event))
            subscribers.push(subscriber);

        if (lastEvent && lastEvent.event === event)
            callback(lastEvent.data);
    };

    let publish = (event, data) => {

        subscribers.forEach(x => {
            if (x.event === event) x.callback(data);
        });

        lastEvent = { event, data };
    };

    return {
        subscribe,
        publish
    }

});