<script setup lang="ts">
import { useBoardStore } from '@/stores/board/board.store'
import { storeToRefs } from 'pinia'
import { useBoardsDrawer } from './composables/useBoardsDrawer'
import BoardDialog from './components/board-dialog/BoardDialog.vue'
import { useFormDialogTemplate } from '../form-dialog-template/composables/useFormDialogTemplate'
import { DialogIds } from '@/enums/DialogIds.enum'

const { boards } = storeToRefs(useBoardStore())
const { state, openDrawer, closeDrawer } = useBoardsDrawer()
const { toggleDialog } = useFormDialogTemplate()
</script>

<template>
  <div v-if="state.isDrawerOpen" class="bg-gray-800 text-white w-64 min-h-screen">
    <button
      class="close-btn bg-green-500 hover:bg-green-800 p-4 m-2 w-10 h-10 flex items-center float-right justify-center text-2xl"
    >
      <font-awesome-icon icon="fa-solid fa-xmark" @click="closeDrawer" />
    </button>
    <div class="py-4 mt-14">
      <ul class="space-y-4 col">
        <li
          v-for="board in boards"
          :key="board.id"
          class="border-b-2 border-b-gray-500 p-4 hover:bg-gray-600"
        >
          <router-link to="/" class="inline-block w-full">
            <p>
              <span class="block w-full">{{ board.name }}</span>
              <span class="block text-gray-500 w-full">{{ board.description }}</span>
            </p>
          </router-link>
        </li>
      </ul>
    </div>
    <div class="p-2 mt-8">
      <button
        class="bg-transparent hover:bg-emerald-600 hover:text-white text-emerald-600 font-semibold rounded-md border-2 border-emerald-600 p-2 w-full"
        @click="toggleDialog(DialogIds.boardDialog)"
      >
        Add new board
      </button>
    </div>
  </div>
  <button
    v-else
    class="close-btn text-white bg-green-500 hover:bg-green-800 p-4 m-2 w-10 h-10 flex items-center float-right justify-center text-2xl"
  >
    <font-awesome-icon icon="fa-solid fa-right-long" @click="openDrawer" />
  </button>

  <board-dialog />
</template>

<style>
.close-btn {
  border-radius: 50%;
}
</style>
