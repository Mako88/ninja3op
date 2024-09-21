import type BaseEvent from "./events/BaseEvent";
import { v4 as uuidV4 } from "uuid";

type Callback<T extends BaseEvent> = (event: T) => Promise<void>;

type Callbacks = {
	[eventType: string]: {
		[id: string]: Callback<BaseEvent>;
	};
};

const callbacks: Callbacks = {};

const addCallback = <T extends BaseEvent>(id: string, eventType: string, callback: Callback<T>) => {
	callbacks[eventType] = {
		...callbacks[eventType],
		[id]: callback as Callback<BaseEvent>,
	};
};

export const subscribe = <T extends BaseEvent>(
	type: { new (...args: Array<never>): T },
	callback: Callback<T>
) => {
	$effect(() => {
		const eventType = new type().getType();
		const id = `${uuidV4()}|${eventType}`;
		addCallback(id, eventType, callback);

		return () => {
			unsubscribe(id);
		};
	});
};

export const publish = <T extends BaseEvent>(event: T) => {
	const eventType = event.getType();

	if (!callbacks[eventType]) {
		return;
	}

	Promise.allSettled(
		Object.keys(callbacks[eventType]).map((id) => {
			callbacks[eventType][id](event);
		})
	);
};

const unsubscribe = (id: string) => {
	const eventType = id.split("|")[1];

	if (callbacks[eventType]) {
		delete callbacks[eventType][id];
	}
};
