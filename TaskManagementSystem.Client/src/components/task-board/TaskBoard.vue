<script setup lang="ts">
import { useTaskBoard } from './composables/useTaskBoard'
import TaskListCard from '../task-list-card/TaskListCard.vue'
import { useBoardStore } from '@/stores/board/board.store'
import { storeToRefs } from 'pinia'
import type { Task } from '@/entities/Task.type'
import TaskDialog from '../task-dialog/TaskDialog.vue'
import type { TaskListDTO } from '@/dtos/TaskList.dto'

const { state } = useTaskBoard()
const store = useBoardStore()
const { currentBoard } = storeToRefs(store)
const { addTaskList } = store

function addNewList() {
  if (currentBoard.value) {
    const taskList: TaskListDTO = {
      id: null,
      name: state.value.newTaskListName
    }

    addTaskList(taskList)

    state.value = {
      hasAddListFormActive: false,
      newTaskListName: ''
    }
  }
}
</script>

<template>
  <template v-if="!currentBoard">
    <div>...loading</div>
  </template>
  <div v-else class="bg-gray-100 h-screen w-screen p-4 flex space-x-4">
    <div v-for="taskList in currentBoard.taskLists" :key="taskList.id as number" class="w-80 h-25">
      <task-list-card :task-list="taskList" />
    </div>
    <template v-if="state.hasAddListFormActive">
      <div class="bg-white max-w-xs h-32 p-4 rounded-md space-y-4">
        <div>
          <input
            type="text"
            v-model="state.newTaskListName"
            class="block border-solid border-opacity-50 border-2 border-gray-600 p-2 rounded-md"
            placeholder="Enter list title..."
          />
        </div>
        <div class="space-x-4">
          <button
            @click="addNewList"
            class="bg-emerald-600 hover:bg-emerald-700 text-white font-semibold rounded-md p-2 disabled:bg-emerald-700 disabled:cursor-not-allowed"
            :disabled="!state.newTaskListName.trim().length"
          >
            Add list
          </button>
          <button
            class="rounded-full py-1 px-4 hover:bg-gray-200"
            @click="state.hasAddListFormActive = false"
          >
            X
          </button>
        </div>
      </div>
    </template>
    <template v-else>
      <button
        @click="state.hasAddListFormActive = true"
        class="bg-white hover:bg-gray-100 text-gray-400 p-4 rounded-md shadow-md h-14"
      >
        + Add task list
      </button>
    </template>
  </div>
  <task-dialog />
</template>
