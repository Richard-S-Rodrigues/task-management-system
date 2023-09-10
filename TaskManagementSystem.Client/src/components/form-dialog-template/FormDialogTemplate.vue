<script setup lang="ts">
import { onMounted, type PropType } from 'vue'
import { useFormDialogTemplate } from './composables/useFormDialogTemplate'
import { DialogIds } from '@/enums/DialogIds.enum'

const props = defineProps({
  dialogId: {
    type: String as PropType<DialogIds>,
    required: true
  }
})

const { isDialogOpen, createDialog, toggleDialog } = useFormDialogTemplate()
const emit = defineEmits(['on-submit'])

onMounted(() => {
  createDialog(props.dialogId)
})

function handleSubmitEvent() {
  toggleDialog(props.dialogId)
  emit('on-submit')
}
</script>

<template>
  <div
    v-if="isDialogOpen(props.dialogId)"
    class="w-full absolute bg-black inset-0 z-0 place-items-center bg-opacity-60 backdrop-blur-sm transition-opacity duration-300"
  >
    <div class="w-full max-w-4xl relative mx-auto mt-8 rounded-xl shadow-lg bg-white">
      <button
        @click="toggleDialog(dialogId)"
        class="hover:bg-gray-200 text-gray-700 rounded-full p-2 w-14 absolute top-0 right-0"
      >
        <font-awesome-icon icon="fa fa-xmark" />
      </button>
      <div>
        <form greedy @submit.prevent="handleSubmitEvent">
          <div class="p-4">
            <slot name="body" />
          </div>

          <footer class="bg-gray-100 rounded-b-md p-4 space-x-4 flex justify-end">
            <button
              class="bg-transparent border-red-700 border-2 rounded-md p-2 text-red-700 w-20"
              @click="toggleDialog(dialogId)"
            >
              Cancel
            </button>
            <button
              class="bg-emerald-600 hover:bg-emerald-700 text-white font-semibold rounded-md p-2 w-20"
              type="submit"
            >
              Save
            </button>
          </footer>
        </form>
      </div>
    </div>
  </div>
</template>
