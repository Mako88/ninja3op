<script lang="ts">
	import "$lib/css/global.css.svelte";
	import "@shoelace-style/shoelace/dist/themes/light.css";
	import "@fontsource/source-sans-pro";
	import "@fontsource-variable/comfortaa";
	import { onMount, type Snippet } from "svelte";
	import type { LayoutData } from "./$types.js";
	import { publish } from "$lib/eventBus/eventBus.svelte";
	import { UserLoggedInEvent } from "$lib/eventBus/events/UserLoggedInEvent";

	type Props = {
		data: LayoutData;
		children: Snippet;
	};

	const { data, children }: Props = $props();

	onMount(async () => {
		await import("@shoelace-style/shoelace/dist/shoelace.js");

		if (data.loggedIn) {
			publish(new UserLoggedInEvent());
		}
	});
</script>

{@render children()};
