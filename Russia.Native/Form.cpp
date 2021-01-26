#include "Form.h"
#include <exception>


LRESULT Form::StaticProcessor(HWND h, UINT m, WPARAM w, LPARAM l) {
	switch (m) {
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	default:
		return DefWindowProc(h, m, w, l);
	}
}

LRESULT Form::Processor(HWND h, UINT m, WPARAM w, LPARAM l) {
	return LRESULT();
}

Form::Form(HINSTANCE hinstance) {
	WNDCLASS wc{ 0 };
	wc.lpfnWndProc = StaticProcessor;
	wc.hInstance = hinstance;
	wc.hCursor = LoadCursor(nullptr, IDC_ARROW);
	wc.lpszClassName = className;
	wc.style = CS_VREDRAW | CS_HREDRAW | CS_OWNDC;
	RegisterClass(&wc);

	int sw = GetSystemMetrics(SM_CXSCREEN);
	int sh = GetSystemMetrics(SM_CYSCREEN);

	int w = 800;
	int h = 600;

	handle = CreateWindow(className, className, WS_OVERLAPPEDWINDOW, sw / 2 - w / 2, sh / 2 - h / 2, w, h, HWND_DESKTOP, nullptr, hinstance, nullptr);
	if (!handle) {
		throw std::exception("Cannot to create a window.");
	}

	ShowWindow(handle, SW_NORMAL);
	UpdateWindow(handle);
}

Form::~Form() {
	DestroyWindow(handle);
}

void Form::Run() {
	MSG msg;
	while (GetMessage(&msg, nullptr, 0, 0)) {
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
}
