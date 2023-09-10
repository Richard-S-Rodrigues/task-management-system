<script setup lang="ts">
import { ref, type PropType } from 'vue'
import type { Task } from '@/entities/Task.type'
import { useTaskDialog } from '@/components/task-dialog/composables/useTaskDialog'

const props = defineProps({
  taskList: {
    type: Object as PropType<Task>,
    required: true
  }
})

const taskList = ref<Task>(props.taskList)
const { toggleDialog } = useTaskDialog()
</script>

<template>
  <div class="bg-white max-w-xs p-4 rounded-md">
    <section>
      <h2 class="text-lg">{{ taskList.name }}</h2>
    </section>
    <section class="my-4 space-y-4">
      <div
        v-for="task in taskList.subTasks"
        :key="task.id as number"
        class="bg-gray-100 p-4 rounded-md"
      >
        {{ task.name }}
      </div>
    </section>
    <section>
      <button
        @click="toggleDialog"
        class="bg-emerald-600 hover:bg-emerald-700 text-white font-semibold rounded-md p-2"
      >
        + Add a task
      </button>
    </section>
  </div>
</template>
