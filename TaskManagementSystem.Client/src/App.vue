<script setup lang="ts">
import { onMounted } from 'vue'
import { useBoardStore } from '@/stores/board/board.store'

const { fetchBoards } = useBoardStore()

onMounted(() => {
  fetchBoards()
})
</script>

<template>
  <router-view />
</template>
