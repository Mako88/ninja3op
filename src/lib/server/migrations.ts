import type { Database } from "better-sqlite3";

interface IMigration {
	version: number;
	name: string;
	up: (db: Database) => void;
	down: (db: Database) => void;
}

export const migrations: IMigration[] = [
	{
		version: 0,
		name: "Create tables",
		up: (db) => {
			db.prepare(
				`CREATE TABLE IF NOT EXISTS users (
          id TEXT NOT NULL PRIMARY KEY
        )`
			).run();

			db.prepare(
				`CREATE TABLE IF NOT EXISTS session (
          id TEXT NOT NULL PRIMARY KEY,
          expires_at INTEGER NOT NULL,
          user_id TEXT NOT NULL,
          FOREIGN KEY (user_id) REFERENCES users(id)
        )`
			).run();

			db.prepare(
				`CREATE TABLE IF NOT EXISTS migrations (
          version INTEGER NOT NULL PRIMARY KEY,
          name TEXT NOT NULL,
          date TEXT NOT NULL
        )`
			).run();

			db.prepare("INSERT INTO users (id) VALUES('test@test.com')").run();
		},
		down: (db) => {
			db.prepare(`DROP TABLE IF EXISTS users`).run();

			db.prepare(`DROP TABLE IF EXISTS session`).run();

			db.prepare(`DROP TABLE IF EXISTS migrations`).run();
		},
	},
];
