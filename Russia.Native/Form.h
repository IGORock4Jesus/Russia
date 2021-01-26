#pragma once

#include <Windows.h>

class Form {
	HWND handle;
	int width, height;
	LPCWSTR className = L"RUSSIA WINDOW";

	static LRESULT CALLBACK StaticProcessor(HWND h, UINT m, WPARAM w, LPARAM l);
	LRESULT Processor(HWND h, UINT m, WPARAM w, LPARAM l);

public:
	Form(HINSTANCE hinstance);
	~Form();

	void Run();

	HWND GetHandle() const { return handle; }
	int GetWidth() const {
		RECT rect;
		GetClientRect(handle, &rect);
		return rect.right - rect.left;
	}
	int GetHeight() const {
		RECT rect;
		GetClientRect(handle, &rect);
		return rect.bottom - rect.top;
	}
};

