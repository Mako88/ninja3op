<script lang="ts">
	import type { SlInput } from "@shoelace-style/shoelace";

	type Props = {
		index: number;
	};

	let { index }: Props = $props();

	let hasInput: boolean = $state(false);

	let nameInput: SlInput | undefined = $state();
	let gradeInput: SlInput | undefined = $state();
	let birthdayInput: SlInput | undefined = $state();

	const getLabel = (label: string): string => {
		const count = index != 0 ? ` ${index + 1}` : "";

		return `Child${count} ${label}`;
	};

	const getRequired = (): string | undefined => {
		return index === 0 || hasInput ? "required" : undefined;
	};

	const inputChanged = () => {
		hasInput = !!(nameInput?.value || gradeInput?.value || birthdayInput?.value);
	};
</script>

<sl-input
	label={getLabel("Name")}
	name={getLabel("Name")}
	style="grid-column: 1 / 3"
	required={getRequired()}
	bind:this={nameInput}
	oninput={inputChanged}>
</sl-input>
<sl-input
	label={getLabel("Grade")}
	name={getLabel("Grade")}
	style="grid-column: 3 / 5"
	required={getRequired()}
	bind:this={gradeInput}
	oninput={inputChanged}>
</sl-input>
<sl-input
	label={getLabel("Birthday")}
	name={getLabel("Birthday")}
	style="grid-column: 5 / 7"
	type="date"
	required={getRequired()}
	bind:this={birthdayInput}
	oninput={inputChanged}>
</sl-input>
