CREATE TABLE IF NOT EXISTS "task_list" (
  "id" int GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
  "name" text not null,
  "task_board_id" int not null,
  "created_at" timestamp not null,
  "updated_at" timestamp not null,
  constraint "fk_task_list_task_board"
    foreign key ("task_board_id")
    references "task_board" ("id")
);