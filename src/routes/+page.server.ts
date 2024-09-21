import { lucia } from "$lib/server/auth";
import type { Actions } from "./$types";

export const actions = {
	mainForm: async (event) => {
		const formData = await event.request.formData();

		console.log(formData.get("Name"));

		for (const pair of formData.entries()) {
			console.log(pair[0], pair[1]);
		}
	},

	login: async (event) => {
		const formData = await event.request.formData();

		const email = formData.get("Email")?.toString();

		lucia.createSession(email!, {});

		console.log(formData.get("Email"));
		console.log(formData.get("Password"));

		for (const pair of formData.entries()) {
			console.log(pair[0], pair[1]);
		}
	},
} satisfies Actions;
