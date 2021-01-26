#include "Form.h"
#include "Renderer.h"


int WINAPI WinMain(HINSTANCE hinstance, HINSTANCE, LPSTR, int) {
	Form form(hinstance);

	InitializeRenderer(form.GetHandle(), form.GetWidth(), form.GetHeight());

	form.Run();

	ReleaseRenderer();

	return 0;
}