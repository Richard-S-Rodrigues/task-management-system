CREATE TABLE task (
  id serial primary key,
  name text not null,
  description text,
  status int not null,
  sub_tasks serial[] not null,
  created_at timestamp not null,
  updated_at timestamp not null,
) 