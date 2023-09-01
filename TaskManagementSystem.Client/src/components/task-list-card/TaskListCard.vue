<script setup lang="ts">
import { useTaskListCard } from './composables/useTaskListCard.ts'

const { taskItems } = useTaskListCard()
</script>

<template>
  <div class="bg-white max-w-xs p-4 rounded-md">
    <section>
      <h2 class="text-lg">Task list item</h2>
    </section>
    <section class="my-4 space-y-4">
      <div v-for="task in taskItems" :key="task.id" class="bg-gray-100 p-4 rounded-md">
        {{ task.name }}
      </div>
    </section>
    <section>
      <button class="bg-emerald-600 hover:bg-emerald-700 text-white font-semibold rounded-md p-2">
        + Add a task
      </button>
    </section>
  </div>
</template>
