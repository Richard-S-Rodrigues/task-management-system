import { api } from '@/api'
import type { TaskListDTO } from '@/dtos/TaskList.dto'
import type { TaskList } from '@/entities/TaskList.type'

export async function createTaskListService(taskList: TaskListDTO): Promise<TaskList> {
  return await api.post('/TaskList/Create', taskList)
}
