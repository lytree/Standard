<template>
  <div class="my-flex-column w100 h100">
    <el-card class="mt8" shadow="never" :body-style="{ paddingBottom: '0' }">
      <el-form :model="state.filterModel" :inline="true" @submit.stop.prevent>
        <el-form-item prop="name">
          <el-input v-model="state.filterModel.name" placeholder="名称或编码" @keyup.enter="onQuery" />
        </el-form-item>
        <el-form-item>
          <el-button type="primary" icon="ele-Search" @click="onQuery"> 查询 </el-button>
          <el-button v-auth="'api:admin:dict:add'" type="primary" icon="ele-Plus" @click="onAdd"> 新增 </el-button>
        </el-form-item>
      </el-form>
    </el-card>
    <el-card class="my-fill mt8" shadow="never">
      <el-table v-loading="state.loading" :data="state.configListData" row-key="id" style="width: 100%">
        <el-table-column type="index" width="80" label="#" />
        <el-table-column prop="name" label="设置名" />
        <el-table-column prop="code" label="设置键名" />
        <el-table-column prop="value" label="设置键值" />
        <el-table-column prop="type" label="设置键类型" />
        <el-table-column prop="sort" label="排序" width="60" align="center"/>
        <el-table-column label="状态" width="80" align="center" show-overflow-tooltip>
          <template #default="{ row }">
            <el-tag type="success" v-if="row.enabled">启用</el-tag>
            <el-tag type="danger" v-else>禁用</el-tag>
          </template>
        </el-table-column>
        <!-- <el-table-column prop="remark" label="备注" /> -->
        <el-table-column label="操作" width="180" fixed="right" header-align="center" align="center">
          <template #default="{ row }">
            <!-- <el-button v-auth="'api:admin:cache:clear'" icon="ele-Brush" size="small" text type="danger"
              @click="onClear(row)">清除</el-button> -->
          </template>
        </el-table-column>
      </el-table>
      <div class="my-flex my-flex-end" style="margin-top: 20px">
        <el-pagination v-model:currentPage="state.pageInput.currentPage" v-model:page-size="state.pageInput.pageSize"
          :total="state.total" :page-sizes="[10, 20, 50, 100]" small background @size-change="onSizeChange"
          @current-change="onCurrentChange" layout="total, sizes, prev, pager, next, jumper" />
      </div>
    </el-card>
    <config-form ref="configFormRef" :title="state.configFormTitle"></config-form>
  </div>
</template>

<script lang="ts" setup name="admin/config">
import { ref, reactive, onMounted, getCurrentInstance,defineAsyncComponent } from 'vue'
import { ConfigApi } from '/@/api/admin/Config'
import { ConfigGetPageOutput, PageInputConfigGetPageDto } from '/@/api/admin/data-contracts'
const { proxy } = getCurrentInstance() as any
// 引入组件
const ConfigForm = defineAsyncComponent(() => import('./components/config-form.vue'))

defineProps({
  title: {
    type: String,
    default: '',
  },
})
const emits = defineEmits(['change'])
const tableRef = ref()
const configFormRef = ref()
const state = reactive({
  loading: false,
  configFormTitle: '',
  filterModel: {
    name: '',
  },
  total: 0,

  pageInput: {
    currentPage: 1,
    pageSize: 20,
  } as PageInputConfigGetPageDto,
  configListData: [] as ConfigGetPageOutput[],
  lastCurrentRow: {} as ConfigGetPageOutput,
})

onMounted(() => {
  onQuery()
})

const onQuery = async () => {
  state.loading = true
  const res = await new ConfigApi().getPage(state.pageInput).catch(() => {
    state.loading = false
  })
  state.configListData = res?.data?.list ?? [] as ConfigGetPageOutput[]
  state.loading = false
}

const onAdd = () => {
  state.configFormTitle = '新增系统设置项'
  configFormRef.value.open()
}
const onSizeChange = (val: number) => {
  state.pageInput.pageSize = val
  onQuery()
}

const onCurrentChange = (val: number) => {
  state.pageInput.currentPage = val
  onQuery()
}

const onTableCurrentChange = (currentRow: ConfigGetPageOutput) => {
  if (state.lastCurrentRow?.id != currentRow?.id) {
    state.lastCurrentRow = currentRow
    emits('change', currentRow)
  }
}
</script>

<style scoped lang="scss"></style>
