import { defineStore } from 'pinia'
import { ref, computed } from 'vue'
import { mockBoards } from '../mock/mockBoards'
import type { Task } from '@/entities/Task.type'
import { createTaskListService } from '@/services/taskListService'
import type { TaskListDTO } from '@/dtos/TaskList.dto'
import type { TaskBoard } from '@/entities/TaskBoard.type'
import { taskBoardService } from '@/services/taskBoardService'
import type { TaskBoardDTO } from '@/dtos/TaskBoard.dto'

interface State {
  boards: TaskBoard[]
  currentBoard: TaskBoard | null
}

const state = ref<State>({
  boards: [],
  currentBoard: null
})

export const useBoardStore = defineStore('board', () => {
  async function fetchBoards() {
    state.value.boards = await taskBoardService.getAll()
    state.value.currentBoard = state.value.boards[0]
  }

  async function addNewBoard(board: TaskBoardDTO) {
    await taskBoardService.create(board)
  }

  async function addTaskList(taskList: TaskListDTO) {
    await createTaskListService(taskList)
  }

  const boards = computed(() => state.value.boards)
  const currentBoard = computed(() => state.value.currentBoard)

  return {
    currentBoard,
    boards,
    fetchBoards,
    addNewBoard,
    addTaskList
  }
})
