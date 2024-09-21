import type { LayoutServerLoad } from "./$types";

export const load: LayoutServerLoad = async (event) => {
	let loggedIn = false;

	if (event.locals.user) {
		loggedIn = true;
	}

	return {
		loggedIn,
	};
};
