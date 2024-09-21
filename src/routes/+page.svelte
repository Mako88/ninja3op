<script lang="ts">
	import Header from "$lib/components/Header.svelte";
	import SignUpForm from "$lib/components/pages/home/SignUpForm.svelte";
</script>

<div id="main-wrapper">
	<Header></Header>
	<div id="banner">
		<div style="width: 400px;">
			<h1>A 3rd-option group for homeschoolers in South Carolina</h1>
			<SignUpForm></SignUpForm>
		</div>
		<img src="./logo.png" alt="logo" />
	</div>
	<sl-divider id="line" style="--spacing: 2rem;"></sl-divider>
	<div id="info1" class="column">
		<h2>What is 3rd-option?</h2>
		<p>
			Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec volutpat enim ut commodo
			hendrerit. Sed vitae massa malesuada nibh hendrerit tempor a at dui. Sed congue eu nibh a
			feugiat. Aliquam maximus aliquet magna, quis blandit ex tempus a. Aenean blandit nibh vel orci
			cursus laoreet.
		</p>
	</div>
	<div id="info2" class="column">
		<h2>Getting started with homeschooling</h2>
		<p>
			Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec volutpat enim ut commodo
			hendrerit. Sed vitae massa malesuada nibh hendrerit tempor a at dui. Sed congue eu nibh a
			feugiat. Aliquam maximus aliquet magna, quis blandit ex tempus a. Aenean blandit nibh vel orci
			cursus laoreet.
		</p>
	</div>
	<div id="info3" class="column">
		<h2>High school transcript services</h2>
		<p>
			Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec volutpat enim ut commodo
			hendrerit. Sed vitae massa malesuada nibh hendrerit tempor a at dui. Sed congue eu nibh a
			feugiat. Aliquam maximus aliquet magna, quis blandit ex tempus a. Aenean blandit nibh vel orci
			cursus laoreet.
		</p>
	</div>
</div>

<style lang="scss">
	#main-wrapper {
		display: grid;
		grid-template-columns: repeat(6, 1fr);
		grid-template-areas:
			"header header header header header header"
			"banner banner banner banner banner banner"
			"line line line line line line"
			"info1 info1 info2 info2 info3 info3";
		align-items: center;
		justify-items: center;
	}

	#banner {
		grid-area: banner;
		display: flex;
		justify-content: center;
		align-items: center;
		gap: 250px;
		width: 90%;
		background-color: var(--lightgray);
		padding: 20px;
		border-radius: 5px;
	}

	h1 {
		font-weight: bold;
		font-size: var(--sl-font-size-3x-large);
		color: var(--yellow);
	}

	#line {
		grid-area: line;
		width: 90%;
	}

	.column {
		max-width: 250px;

		h2 {
			font-size: var(--sl-font-size-x-large);
			text-align: center;
			margin: 0 0 10px 0;
			color: var(--yellow);
		}

		p {
			text-align: justify;
		}
	}

	#info1 {
		grid-area: info1;
	}

	#info2 {
		grid-area: info2;
	}

	#info3 {
		grid-area: info3;
	}
</style>
