import type { Board } from '@/entities/Board.type'

export const mockBoards: Board[] = [
  {
    id: 1,
    name: 'Board 1',
    taskLists: [
      {
        id: 1,
        name: 'Task list 1',
        description: null,
        subTasks: [
          {
            id: 2312,
            name: 'Sub task from task list 1',
            description: null,
            subTasks: []
          }
        ]
      },
      {
        id: 2,
        name: 'Task list 2',
        description: null,
        subTasks: [
          {
            id: 2312,
            name: 'Sub task from task list 1',
            description: null,
            subTasks: []
          },
          {
            id: 45323,
            name: 'Sub task from task list 2',
            description: null,
            subTasks: []
          }
        ]
      }
    ]
  }
]
