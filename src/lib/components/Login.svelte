<script>
	import { subscribe } from "$lib/eventBus/eventBus.svelte";
	import { UserLoggedInEvent } from "$lib/eventBus/events/UserLoggedInEvent";
	import Dialog, { DialogButtonType } from "./Dialog.svelte";

	let isLoggedIn = $state(false);

	subscribe(UserLoggedInEvent, async () => {
		isLoggedIn = true;
	});
</script>

{#if isLoggedIn}
	<a href="#top">Account</a>
{:else}
	<Dialog label="Login" title="Login" style="--width: 400px" buttonType={DialogButtonType.Link}>
		<form method="POST" action="/?/login" id="loginform" name="loginform">
			<sl-input label="Email" name="Email" type="email" placeholder="Enter your email..." required
			></sl-input>
			<sl-input
				label="Password"
				name="Password"
				type="password"
				required
				placeholder="Enter your password..."></sl-input>
			<sl-button type="submit" {...{ slot: "footer" }}>Login</sl-button>
		</form>
	</Dialog>
{/if}
