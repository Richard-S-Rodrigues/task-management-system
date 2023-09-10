<script setup lang="ts">
import FormDialogTemplate from '@/components/form-dialog-template/FormDialogTemplate.vue'
import type { TaskBoardDTO } from '@/dtos/TaskBoard.dto'
import { DialogIds } from '@/enums/DialogIds.enum'
import { ref } from 'vue'
import { useBoardStore } from '@/stores/board/board.store'

const state = ref<TaskBoardDTO>({
  id: null,
  name: '',
  description: null
})

const { addNewBoard } = useBoardStore()

function handleSubmit() {
  addNewBoard(state.value)
}
</script>

<template>
  <form-dialog-template :dialog-id="DialogIds.boardDialog" @on-submit="handleSubmit">
    <template #body>
      <div class="space-y-4 my-4">
        <div>
          <label>
            Name*
            <input class="border rounded-md p-2 w-full" required v-model="state.name" />
          </label>
        </div>
        <div>
          <label>
            Description
            <textarea class="w-full border rounded-md" v-model="state.description"></textarea>
          </label>
        </div>
      </div>
    </template>
  </form-dialog-template>
</template>
