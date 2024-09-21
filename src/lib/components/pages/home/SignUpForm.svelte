<script lang="ts">
	import Checkbox from "$lib/components/Checkbox.svelte";
	import Counter from "$lib/components/Counter.svelte";
	import Dialog from "$lib/components/Dialog.svelte";
	import FormChild from "./FormChild.svelte";

	let children = $state(1);
</script>

<Dialog label="Sign Up" title="Sign Up" style="--width: 900px;">
	<form method="POST" class="grid" action="?/mainForm">
		<sl-input label="Name" style="grid-column: 1 / 4" name="Name" required></sl-input>
		<sl-input label="Email" style="grid-column: 4 / 7" name="Email" type="email" required
		></sl-input>
		<sl-input label="Address Line 1" name="Address1" required></sl-input>
		<sl-input label="Address Line 2" name="Address2"></sl-input>
		<sl-input label="City" style="grid-column: 1 / 3" name="City" required></sl-input>
		<sl-input label="State" style="grid-column: 3 / 5" name="State" required></sl-input>
		<sl-input label="Zip Code" style="grid-column: 5 / 7" name="Zip" required></sl-input>
		<sl-input label="School District" name="School" required></sl-input>
		<Counter label="Children:" min={1} max={30} bind:count={children}></Counter>
		{#each { length: children } as _, i}
			<FormChild index={i}></FormChild>
		{/each}
		<p>Please verify the following:</p>
		<Checkbox
			name="Verify1"
			required
			label="I certify that I am the parent/guardian of the students I am registering.">
		</Checkbox>
		<Checkbox name="Verify2" required label="My school year is at least 180 days."></Checkbox>
		<Checkbox
			name="Verify3"
			required
			label="My curriculum includes, but is not limited to, the basic instructional areas of reading,
			writing, mathematics, science, and social studies, and in grades seven through twelve,
			composition, and literature.">
		</Checkbox>
		<Checkbox
			name="Verify4"
			required
			label="I maintain education records which include a plan book, diary, or other record indicating
			subjects taught and activities in which my student(s) and I engage in; a portfolio of samples
			of my student(s) academic work; semiannual progress report including attendance records and
			individualized documentation of my student(s) academic progress in each of the instructional
			areas.">
		</Checkbox>
		<Checkbox
			name="Verify5"
			required
			label="I will send Ninja 3Op my mid-year attendance and end year attendance.">
		</Checkbox>
		<sl-button type="submit" style="grid-column: 6 / 7">Submit</sl-button>
	</form>
</Dialog>

<style>
	.grid {
		display: grid;
		gap: var(--sl-spacing-medium);
		grid-template-columns: repeat(6, 1fr);
		justify-content: space-evenly;
	}

	.grid sl-input,
	.grid :global(sl-checkbox) {
		grid-column: 1 / -1;
	}

	.grid p {
		grid-column: 1 / 3;
	}
</style>
