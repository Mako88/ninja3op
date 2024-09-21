import { Lucia } from "lucia";
import { dev } from "$app/environment";
import { luciaAdapter } from "./db";

export const lucia = new Lucia(luciaAdapter, {
	sessionCookie: {
		attributes: {
			// set to `true` when using HTTPS
			secure: !dev,
		},
	},
});

declare module "lucia" {
	interface Register {
		Lucia: typeof lucia;
	}
}
