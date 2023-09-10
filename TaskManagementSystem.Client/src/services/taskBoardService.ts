import { api } from '@/api'
import type { TaskBoardDTO } from './../dtos/TaskBoard.dto'
import type { TaskBoard } from './../entities/TaskBoard.type'

export const taskBoardService = {
  async getAll(): Promise<TaskBoard[]> {
    try {
      const response = await api.get('/TaskBoard/GetAll')
      return response.data
    } catch {
      return []
    }
  },
  async getById(id: number): Promise<TaskBoard | null> {
    try {
      const response = await api.get(`/TaskBoard/GetById/${id}`)
      return response.data
    } catch {
      return null
    }
  },
  async create(taskBoardDto: TaskBoardDTO): Promise<void> {
    await api.post('/TaskBoard/Create', taskBoardDto)
  },
  async update(id: number, taskBoardDto: TaskBoardDTO): Promise<TaskBoard | null> {
    try {
      const response = await api.put(`/TaskBoard/Update/${id}`, taskBoardDto)
      return response.data
    } catch {
      return null
    }
  },
  async delete(id: number): Promise<void> {
    await api.delete(`/TaskBoard/Delete/${id}`)
  }
}
