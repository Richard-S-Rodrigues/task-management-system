import { api } from '@/api'
import type { Task } from './../entities/Task.type'
import type { TaskDTO } from '@/dtos/Task.dto'

export async function createSubTaskService(parentId: number, subTask: TaskDTO): Promise<Task> {
  return await api.post('/Task/CreateSubTask', { parentId, request: subTask })
}
