import { ref, computed } from 'vue'

interface State {
  isOpen: boolean
}

const state = ref<State>({ isOpen: false })

export function useTaskDialog() {
  function toggleDialog() {
    state.value.isOpen = !state.value.isOpen
  }

  return {
    isOpen: computed(() => state.value.isOpen),
    toggleDialog
  }
}
