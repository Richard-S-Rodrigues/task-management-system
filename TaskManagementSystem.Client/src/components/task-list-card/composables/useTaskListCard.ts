import { ref } from 'vue'

interface TaskItem {
  id: number
  name: string
}

const taskItems = ref<TaskItem[]>([
  {
    id: 1,
    name: 'Test 1'
  },
  {
    id: 2,
    name: 'Test 2'
  },
  {
    id: 3,
    name: 'Test 3'
  }
])

export function useTaskListCard() {
  return {
    taskItems
  }
}
