import { ref } from 'vue'
interface State {
  isDrawerOpen: boolean
}

const state = ref<State>({
  isDrawerOpen: true
})

export function useBoardsDrawer() {
  function openDrawer() {
    state.value.isDrawerOpen = true
  }

  function closeDrawer() {
    state.value.isDrawerOpen = false
  }

  return {
    state,
    openDrawer,
    closeDrawer
  }
}
