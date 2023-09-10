export interface TaskDTO {
  id: number | null
  name: string
  description: string | null
  subTasks: number[]
}
