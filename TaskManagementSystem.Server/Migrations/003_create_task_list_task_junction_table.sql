CREATE TABLE IF NOT EXISTS "task_list_task" (
  "task_list_id" int not null,
  "task_id" int not null,
  primary key ("task_list_id", "task_id"),
  foreign key ("task_list_id") references "task_list"("id"),
  foreign key ("task_id") references "task"("id")
);