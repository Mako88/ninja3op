<style global lang="scss">
	*,
	*:after,
	*:before {
		-webkit-box-sizing: border-box;
		-moz-box-sizing: border-box;
		box-sizing: border-box;
	}

	:root {
		--darkyellow: #917727;
		--yellow: #ffd34c;
		--lightyellow: #fffbef;
		--darkgray: var(--sl-color-gray-900);
		--medgray: var(--sl-color-gray-700);
		--lightgray: var(--sl-color-gray-600);
		--white: var(--sl-color-gray-50);
	}

	body {
		font-family: "Comfortaa Variable", system-ui, sans-serif;
		margin: 0;
		background-color: var(--darkgray);
		color: var(--white);
	}

	:not(:defined) {
		visibility: hidden;
	}

	a {
		&,
		&:link,
		&:visited,
		&:active {
			color: var(--white);
			text-decoration: none;
		}

		&:hover {
			color: var(--yellow);
		}
	}

	sl-dialog::part(panel) {
		background-color: var(--medgray);
	}

	sl-button::part(base) {
		background-color: var(--white);

		&:hover {
			background-color: var(--lightyellow);
			color: var(--darkyellow);
		}
	}
</style>
