<script lang="ts">
	type Props = {
		name: string;
		required: boolean;
		label: string;
	};

	let { name, required, label, ...everythingElse }: Props = $props();
</script>

<sl-checkbox {name} {required} {...everythingElse} value={label}>
	{label}
</sl-checkbox>
