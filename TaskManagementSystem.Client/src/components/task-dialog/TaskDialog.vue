<script setup lang="ts">
import { ref } from 'vue'
import { useTaskDialog } from './composables/useTaskDialog'
import type { TaskDTO } from '@/dtos/Task.dto'
import { createSubTaskService } from '@/services/taskService'

const { isOpen, toggleDialog } = useTaskDialog()

const subTaskName = ref('')
const subTasks = ref([])

async function addSubTask(taskName: string) {
  const newSubTask: TaskDTO = {
    id: null,
    name: taskName,
    description: null,
    subTasks: []
  }

  subTasks.value = [...subTasks.value, { name: subTaskName.value, isEditing: false }]
  subTaskName.value = ''
}

function setSubTaskToSave(task: any) {
  subTaskName.value = task.name
  toggleSubTaskEditing(task)
}

function toggleSubTaskEditing(task: any) {
  task.isEditing = !task.isEditing
}
</script>

<template>
  <div
    v-if="isOpen"
    class="w-full absolute bg-black inset-0 z-0 place-items-center bg-opacity-60 backdrop-blur-sm transition-opacity duration-300"
  >
    <div class="w-full max-w-4xl relative mx-auto mt-8 rounded-xl shadow-lg bg-white">
      <div class="space-y-10 p-4">
        <section class="flex justify-between">
          <div class="w-full space-y-2">
            <h3>Title</h3>
            <input class="border rounded-md p-2 w-full" />
          </div>
          <div>
            <button
              @click="toggleDialog"
              class="hover:bg-gray-200 text-gray-700 rounded-full p-2 w-14"
            >
              X
            </button>
          </div>
        </section>
        <section class="space-y-2">
          <h3>Description</h3>
          <textarea class="w-full border rounded-md"></textarea>
        </section>
        <section class="space-y-2">
          <h3>SubTasks</h3>
          <input
            class="border rounded-md p-2 w-full"
            placeholder="new subTask"
            v-model="subTaskName"
            @keyup.enter="addSubTask"
          />
          <div
            v-for="(subTask, index) in subTasks"
            :key="index"
            class="border rounded-md p-2 w-full flex justify-between"
          >
            <span>
              {{ subTask.name }}
            </span>
            <span class="space-x-6">
              <font-awesome-icon icon="fa-solid fa-pen-to-square" style="cursor: pointer" />
              <font-awesome-icon icon="fa-solid fa-trash" style="cursor: pointer" />
            </span>
          </div>
        </section>
      </div>
      <footer class="bg-gray-100 rounded-b-md p-4 space-x-4 flex justify-end">
        <button class="bg-transparent border-red-700 border-2 rounded-md p-2 text-red-700 w-20">
          Cancel
        </button>
        <button
          class="bg-emerald-600 hover:bg-emerald-700 text-white font-semibold rounded-md p-2 w-20"
        >
          Save
        </button>
      </footer>
    </div>
  </div>
</template>
