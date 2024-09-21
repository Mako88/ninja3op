<script lang="ts">
	type Props = {
		count: number;
		label: string;
		min?: number;
		max?: number;
	};

	let { count = $bindable(), label, min, max }: Props = $props();

	count = min ?? 1;

	let countInput: HTMLElement;

	const decreaseCount = () => {
		if (!min) {
			count--;
			return;
		}

		if (count > min) {
			count--;
		}
	};

	const setCount = (event: Event) => {
		const value = parseInt((event.target as HTMLInputElement).value);

		if (isNaN(value)) {
			return;
		}

		if (min && value < min) {
			count = min;
			return;
		}

		if (max && value > max) {
			count = max;
			return;
		}

		count = value;
	};

	const countInputKeyDown = (event: KeyboardEvent) => {
		if (event.key == "Enter") {
			event.preventDefault();
		}
	};

	const buttonKeyUp = (event: KeyboardEvent, increase: boolean) => {
		if (event.key != "Tab") {
			increase ? count++ : count--;
		}
	};

	const increaseCount = () => {
		if (!max) {
			count++;
			return;
		}

		if (count < max) {
			count++;
		}
	};
</script>

<p>
	{label}
	<sl-icon-button
		name="dash-circle"
		label="Reduce child count"
		onclick={decreaseCount}
		onkeyup={(event: KeyboardEvent) => buttonKeyUp(event, false)}
		role="button"
		tabindex="0">
	</sl-icon-button>
	<input
		type="text"
		value={count}
		oninput={setCount}
		style="width: 1em"
		onkeydown={countInputKeyDown}
		bind:this={countInput} />
	<sl-icon-button
		name="plus-circle"
		label="Increase child count"
		onclick={increaseCount}
		onkeyup={(event: KeyboardEvent) => buttonKeyUp(event, true)}
		role="button"
		tabindex="0">
	</sl-icon-button>
</p>

<style>
	sl-icon-button {
		padding: 0 5px;
	}

	p {
		grid-column: 1 / 3;
		display: flex;
		align-items: center;
	}
</style>
