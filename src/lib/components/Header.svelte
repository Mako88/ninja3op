<script>
	import Login from "./Login.svelte";
</script>

<div id="header">
	<Login></Login>
</div>

<style>
	#header {
		display: flex;
		align-items: center;
		gap: var(--sl-spacing-small);
		background-color: var(--darkgray);
		grid-area: header;
		color: var(--white);
		justify-content: flex-end;
		padding: var(--sl-spacing-medium);
		margin: 0;
		width: 100%;
	}
</style>
