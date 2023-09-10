<script setup lang="ts">
import TaskBoard from '../components/task-board/TaskBoard.vue'
import BoardsDrawer from '../components/boards-drawer/BoardsDrawer.vue'
</script>

<template>
  <main class="flex">
    <boards-drawer />
    <task-board />
  </main>
</template>
