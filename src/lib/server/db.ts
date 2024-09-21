import { BetterSqlite3Adapter } from "@lucia-auth/adapter-sqlite";
import sqlite from "better-sqlite3";
import { migrations } from "./migrations";

const databaseFile = "database.sqlite";

const db = new sqlite(databaseFile);
db.pragma("journal_mode = WAL");

export const migrateDb = () => {
	console.log("Migrating database");

	let currentMigration = -1;
	const migrationsTableExists = db
		.prepare("SELECT 1 FROM sqlite_master WHERE type='table' AND name='migrations'")
		.get() as number;

	if (migrationsTableExists) {
		currentMigration = db.prepare("SELECT MAX(version) FROM migrations").get() as number;
	}

	for (const migration of migrations
		.filter((x) => x.version > currentMigration)
		.sort((a, b) => a.version - b.version)) {
		console.log(`Running migration '${migration.name}'`);

		db.transaction(() => {
			migration.up(db);
			db.prepare(
				"INSERT INTO migrations (version, name, date) VALUES (@version, @name, DATE('now'))"
			).run({ version: migration.version, name: migration.name });
		})();
	}

	console.log(db.prepare("SELECT * from migrations").get());
};

export const luciaAdapter = new BetterSqlite3Adapter(db, {
	user: "user",
	session: "session",
});
