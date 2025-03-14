import { createRouter, createWebHistory } from "vue-router";
import Layout from "../layout/Index.vue";
import NotFound from "../views/error/404.vue";
import LoginLayout from "../layout/LoginLayout.vue";
import ActivityLayout from "../layout/activity/Index.vue";
import ChatLayout from "../layout/ChatLayout.vue"
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  scrollBehavior(to, from, savedPosition) {
    // 始终滚动到顶部
    return { top: 0 };
  },
  routes: [
    {
      path: "/loginLayout",
      name: "loginLayout",
      component: LoginLayout,
      redirect: "/login",
      children: [
        {
          name: "login",
          path: "/login",
          // component: () => import("../views/Login.vue"),
          component: () => import("../views/login/login.vue"),
        },
        {
          name: "register",
          path: "/register",
          component: () => import("../views/login/register.vue"),
        },
        {
          name: "forgotPassword",
          path: "/forgotPassword",
          component: () => import("../views/login/forgotPassword.vue"),
        }
      ],
    },
    {
      name: "stock",
      path: "/index",
      component: () => import("../views/stock/Index.vue"),
      meta: {
        title: "股票",
      },
    },
    { path: "/:pathMatch(.*)*", name: "NotFound", component: NotFound },
  ],
});

export default router;
