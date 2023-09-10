import { ref } from 'vue'

interface State {
  newTaskListName: string
  hasAddListFormActive: boolean
}

const state = ref<State>({
  newTaskListName: '',
  hasAddListFormActive: false
})

export function useTaskBoard() {
  return {
    state
  }
}
