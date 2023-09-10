import { DialogIds } from '@/enums/DialogIds.enum'
import { ref } from 'vue'

type State = {
  [dialogId in DialogIds]: {
    isOpen: boolean
  }
}

const state = ref<State>({} as State)

export function useFormDialogTemplate() {
  function createDialog(dialogId: DialogIds) {
    state.value[dialogId] = {
      isOpen: false
    }
  }

  function toggleDialog(dialogId: DialogIds) {
    state.value[dialogId].isOpen = !state.value[dialogId].isOpen
  }

  function isDialogOpen(dialogId: DialogIds) {
    return state.value[dialogId] && state.value[dialogId].isOpen
  }

  return {
    state,
    createDialog,
    toggleDialog,
    isDialogOpen
  }
}
