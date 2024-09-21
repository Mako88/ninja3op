<script lang="ts" context="module">
	export enum DialogButtonType {
		Link,
		Button,
	}
</script>

<script lang="ts">
	import type { SlDialog } from "@shoelace-style/shoelace";
	import type { Snippet } from "svelte";

	type Props = {
		label: string;
		title: string;
		children: Snippet;
		style?: string;
		buttonType?: DialogButtonType;
		confirmButtons?: string;
	};

	let {
		label,
		title,
		children,
		style,
		buttonType = DialogButtonType.Button,
		confirmButtons,
	}: Props = $props();

	let dialog: SlDialog | undefined = $state();
</script>

{#if buttonType === DialogButtonType.Button}
	<sl-button
		onclick={() => dialog?.show()}
		onkeyup={dialog?.show()}
		role="button"
		tabindex="0"
		size="large"
		style="width: 60%">
		{label}
	</sl-button>
{:else}
	<a href="#top" onclick={() => dialog?.show()}>
		{label}
	</a>
{/if}

<sl-dialog label={title} bind:this={dialog} {style}>
	{@render children()}
</sl-dialog>
